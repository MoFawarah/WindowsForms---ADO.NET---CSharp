import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CategoriesComponent } from './components/Admin/categories/categories.component';
import { AddCategoryComponent } from './components/Admin/add-category/add-category.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SingleCategoryComponent } from './components/Admin/single-category/single-category.component';
import { BlogpostsListComponent } from './components/Admin/blogPost/blogposts-list/blogposts-list.component';
import { AddBlogPostComponent } from './components/Admin/blogPost/add-blog-post/add-blog-post.component';
import { MarkdownModule } from 'ngx-markdown';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CategoriesComponent,
    AddCategoryComponent,
    HomeComponent,
    SingleCategoryComponent,
    BlogpostsListComponent,
    AddBlogPostComponent
  ],
  imports: [
    MarkdownModule.forRoot(),
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
