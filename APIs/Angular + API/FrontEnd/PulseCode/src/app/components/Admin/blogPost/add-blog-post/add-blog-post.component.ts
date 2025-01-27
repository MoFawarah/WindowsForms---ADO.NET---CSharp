import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BlogPostService } from 'src/app/blogPostServices/blog-post.service';
import { BlogPostRequest } from 'src/app/interfaces/blog-post-request';
import { Category } from 'src/app/interfaces/category';
import { UrlService } from 'src/app/services/url.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-blog-post',
  templateUrl: './add-blog-post.component.html',
  styleUrls: ['./add-blog-post.component.css']
})
export class AddBlogPostComponent implements OnInit {
  data : BlogPostRequest;
  minDate: string = '';
  categoryData: Category[] = [];
  

  ngOnInit() {
    const today = new Date();
    this.minDate = today.toISOString().split('T')[0];
    this.getAllCategories();


    
   
  }

  constructor(private _blogPostService: BlogPostService, private _categoryService: UrlService, private _router: Router) {
    this.data = {
      title: '',
      shortDescription : '',
      content: '',
      featuredImageUrl: '',
      urlHandle: '',
      publishedDate: new Date(),
      author: '',
      isVisible: true,
      categoriesID: []
     }

  }

  addBlogPost() {
    debugger
    
    this._blogPostService.createBlogPost(this.data).subscribe({
      next: (response) => {
        Swal.fire({
          title: 'Success!',
          text: 'Blog Post Added Successfuly.',
          icon: 'success',
          confirmButtonText: 'Cool'
        }).then(() => {
          this._router.navigate(['admin/blogpost']);
        })
     
        
      },
      error: (error) => {
        console.error(error);
      }
     });
    }

    getAllCategories(){
      this._categoryService.getAllCategories().subscribe({
        next: (response) => {
          this.categoryData = response;
          console.log(this.categoryData);
        
        },
        error: (error) => {
          console.error(error);
        }
      })
    }
  }



