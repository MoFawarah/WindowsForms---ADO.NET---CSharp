import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogPostRequest } from '../interfaces/blog-post-request';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BlogPostResponse } from '../interfaces/blog-post-response';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {

  constructor(private http:HttpClient) { }


  createBlogPost(data: BlogPostRequest ): Observable<BlogPostResponse> {
    debugger
  return this.http.post<BlogPostResponse>(`${environment.apiBaseUrl}/BlogPosts/CreateBlogPost`, data)
  }

  getAllBlogPost() : Observable<BlogPostResponse[]> {
    return this.http.get<BlogPostResponse[]>(`${environment.apiBaseUrl}/BlogPosts/GetAllBlogPosts`)
  }

}
