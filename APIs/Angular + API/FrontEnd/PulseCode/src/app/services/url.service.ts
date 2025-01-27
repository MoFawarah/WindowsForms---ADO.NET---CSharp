import { EnvironmentInjector, Injectable } from '@angular/core';
import { Observable, ObservableInputTuple } from 'rxjs';
import { IAddCategoryRequest } from '../interfaces/iadd-category-request';
import { HttpClient } from '@angular/common/http';
import { Category } from '../interfaces/category';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UrlService {
  
  

  constructor(private http: HttpClient ) { }

  addCategory(data : IAddCategoryRequest): Observable<any>{
  return this.http.post<any>(`${environment.apiBaseUrl}/Categories/CreateCategory`, data)
  }

  getAllCategories() : Observable<Category[]> {
    return this.http.get<Category[]>(`${environment.apiBaseUrl}/Categories/GetAllCategories`)
  }

  getSingleCategory(id: string) : Observable<Category> {
    return this.http.get<Category>(`${environment.apiBaseUrl}/Categories/${id}`)
  }

  updateCategory(id: string, data: IAddCategoryRequest) : Observable<Category> {
    return this.http.put<Category>(`${environment.apiBaseUrl}/Categories/UpdateCategory/${id}`, data)
  }

  deleteCategory(id: string) : Observable<Category> {
    return this.http.delete<Category>(`${environment.apiBaseUrl}/Categories/DeleteCategory/${id}`)
  }
}
