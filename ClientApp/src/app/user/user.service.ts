import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'api/user');
  }
  addUser(user: User): Observable<boolean> {
    return this.http.post<boolean>(this.baseUrl + 'api/user', user);
  }
  updateUser(user: User): Observable<boolean> {
    return this.http.put<boolean>(this.baseUrl + 'api/user', user);
  }
  deleteUser(id: string): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + 'api/user' + id);
  }
}
