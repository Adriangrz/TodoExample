import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AddTodo, Todo } from '../types';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  constructor(private http: HttpClient) {}

  addTodo(todo: AddTodo) {
    return this.http.post<Todo>('/api/Todo', todo);
  }

  getTodos() {
    return this.http.get<Todo[]>('/api/Todo');
  }

  deleteTodo(id: string) {
    return this.http.delete(`/api/Todo/${id}`);
  }

  updateTodo(todo: Todo) {
    return this.http.put('/api/Todo', todo);
  }
}
