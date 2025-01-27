import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogPostService } from 'src/app/blogPostServices/blog-post.service';
import { BlogPostResponse } from 'src/app/interfaces/blog-post-response';

@Component({
  selector: 'app-blogposts-list',
  templateUrl: './blogposts-list.component.html',
  styleUrls: ['./blogposts-list.component.css']
})
export class BlogpostsListComponent {

  //1. for async pipe (another way to display the data in the table):
  data$?: Observable<BlogPostResponse[]>

  data : BlogPostResponse[] = [];

  ngOnInit(){


  //2. for async pipe (another way to display the data in the table):
  this.data$ = this._blogPostsService.getAllBlogPost();

  this.data$.forEach(element => {
    console.log(element);
  });


    this.getAllBlogPosts(); 

  }



  constructor(private _blogPostsService: BlogPostService ){
    
   
  }

  getAllBlogPosts(){
    this._blogPostsService.getAllBlogPost().subscribe({
     next : (response) => {
       this.data = response;
     },
     error : (error) => {
       console.error(error);
       alert("Please try again later")  
     }
    })

  }
}
