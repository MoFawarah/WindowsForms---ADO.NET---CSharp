import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/interfaces/category';
import { IAddCategoryRequest } from 'src/app/interfaces/iadd-category-request';
import { UrlService } from 'src/app/services/url.service';

@Component({
  selector: 'app-single-category',
  templateUrl: './single-category.component.html',
  styleUrls: ['./single-category.component.css']
})
export class SingleCategoryComponent implements OnInit, OnDestroy {

  currentCategoryId: string | null = null;
  currentCategory?: Category
  Subscription?: Subscription

  editCategorySubscription?: Subscription

  updateCategoryRequest : IAddCategoryRequest


  constructor(private _ser: UrlService, private _route: ActivatedRoute, private _router: Router) {

   this.updateCategoryRequest = {
     name: '',
     urlHandle: ''
   }

  }




  ngOnInit() {
   
    this.Subscription = this._route.paramMap.subscribe({
      next: (params) => {
        this.currentCategoryId = params.get('id');


        if (this.currentCategoryId) {
          this._ser.getSingleCategory(this.currentCategoryId).subscribe({
            next: (Response) => {
              this.currentCategory= Response;


            },
            error: (error) => {
              alert("Please try again later")
            }
          })
        }
      }
    })


  }

  ngOnDestroy(): void {
    this.Subscription?.unsubscribe()
    this.editCategorySubscription?.unsubscribe()
  }

  updateCategory(){
    this.updateCategoryRequest = {
      name: this.currentCategory?.name ?? "",
      urlHandle: this.currentCategory?.urlHandle ?? ""
    }
    
    if(this.currentCategoryId != null)
    {
     this.editCategorySubscription = this._ser.updateCategory(this.currentCategoryId, this.updateCategoryRequest).subscribe({
        next: (Response) => {
         
          alert("Category updated successfully")
          this._router.navigate(['admin/category'])

        },
        error: (error) => {
          alert("Failed to update category. Please try again.")
        }
      })
    }
    
    
  }






}
