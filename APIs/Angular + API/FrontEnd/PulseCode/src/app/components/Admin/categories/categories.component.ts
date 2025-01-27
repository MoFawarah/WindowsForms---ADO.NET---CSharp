import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Category } from 'src/app/interfaces/category';
import { UrlService } from 'src/app/services/url.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categories$? : Observable<Category[]>
  ngOnInit() {
    this.getAllCategories();

  }
  constructor(private _ser: UrlService, private _router: Router) {

  }

  getAllCategories() { 
   this.categories$ = this._ser.getAllCategories()
    }

    confirmDelete(id: string) {
      Swal.fire({
        title: 'Warning!',
        text: 'Are you sure you want to delete this Category?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
      }).then((result) => {
        if (result.isConfirmed) {
          this._ser.deleteCategory(id).subscribe({
            next: (response) => {
              Swal.fire({
                title: 'Success!',
                text: 'Category deleted successfully.',
                icon: 'success',
                confirmButtonText: 'Close'
              });
              this.getAllCategories();
            },
            error: (error) => {
              console.error(error);
              Swal.fire({
                title: 'Error!',
                text: 'Failed to delete category.',
                icon: 'error',
                confirmButtonText: 'Close'
              });
            }
          });
        } 
        else {
          Swal.fire({
            title: 'Action Canceled',
            text: 'The category deletion was canceled.',
            icon: 'info',
            confirmButtonText: 'Okay'
          });
        }
      });
    }
    

}
