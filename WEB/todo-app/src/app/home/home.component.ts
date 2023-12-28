import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterLink } from '@angular/router';

import { TodoService } from '../services/todo.service';

import { Todo } from '../types';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    MatListModule,
    MatProgressSpinnerModule,
    RouterLink,
  ],
  providers: [TodoService],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  todos: Todo[] = [];
  isError: boolean = false;
  isLoading: boolean = false;

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.getTodos();
  }

  getTodos() {
    this.isLoading = true;
    this.todoService.getTodos().subscribe({
      next: (data: Todo[]) => {
        this.todos = data;
        this.isLoading = false;
      },
      error: () => {
        this.isError = true;
        this.isLoading = false;
      },
    });
  }

  deleteTodo(id: string) {
    this.isLoading = true;
    this.todoService.deleteTodo(id).subscribe({
      next: () => {
        this.getTodos();
      },
      error: () => {
        this.isError = true;
        this.isLoading = false;
      },
    });
  }

  onCheckboxChange(id: string, isChecked: boolean) {
    this.isLoading = true;

    let index = this.todos.findIndex((element) => element.id == id);
    this.todos[index].isDone = isChecked;

    this.todoService.updateTodo(this.todos[index]).subscribe({
      next: () => {
        this.isLoading = false;
      },
      error: () => {
        this.isError = true;
        this.isLoading = false;
      },
    });
  }
}
