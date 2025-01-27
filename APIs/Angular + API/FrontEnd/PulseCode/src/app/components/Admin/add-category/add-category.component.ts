import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IAddCategoryRequest } from 'src/app/interfaces/iadd-category-request';
import { UrlService } from 'src/app/services/url.service';
import Swal from 'sweetalert2';



@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

  model : IAddCategoryRequest

  private addCategorySubscription! : Subscription

  constructor(private _ser: UrlService, private _router: Router){
    this.model = {
      name: '',
      urlHandle: ''
    }
  }
  ngOnDestroy(): void {
    this.addCategorySubscription.unsubscribe()
  }

  addCategory() {
 
  //  var formData = new FormData()

  //  formData.append('name', this.model.name);
  //  formData.append('urlHandle', this.model.urlHandle);

   this.addCategorySubscription = this._ser.addCategory(this.model).subscribe({
    next: (Response) => {
      console.log(Response.name);
      Swal.fire({
        title: 'Success!',
        text: 'Category Added Successfuly.',
        icon: 'success',
        confirmButtonText: 'Okay'
      }).then(() => { ;
      this._router.navigate(['/admin/category']); 
      });
    
    },
    error: (err) => {
      Swal.fire({
        title: 'Error!',
        text: 'Failed to add category. Please try again.',
        icon: 'error',
        confirmButtonText: 'Okay'
      });
    },

   })
    

  }

}
