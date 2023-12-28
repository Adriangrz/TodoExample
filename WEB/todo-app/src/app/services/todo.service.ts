import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Todo } from '../types';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  constructor(private http: HttpClient) {}

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
