import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './components/Admin/categories/categories.component';
import { AppComponent } from './app.component';
import { AddCategoryComponent } from './components/Admin/add-category/add-category.component';
import { HomeComponent } from './components/home/home.component';
import { SingleCategoryComponent } from './components/Admin/single-category/single-category.component';
import { BlogpostsListComponent } from './components/Admin/blogPost/blogposts-list/blogposts-list.component';
import { AddBlogPostComponent } from './components/Admin/blogPost/add-blog-post/add-blog-post.component';

const routes: Routes = [
  {path: 'home', component: HomeComponent, pathMatch: "full"},
  {path: "admin/category", component: CategoriesComponent},
  {path: "admin/addCategory", component: AddCategoryComponent},
  {path: "admin/singleCategory/:id", component: SingleCategoryComponent},
  {path: "admin/blogpost", component: BlogpostsListComponent},
  {path: "admin/blogpost/add", component: AddBlogPostComponent}
  


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
