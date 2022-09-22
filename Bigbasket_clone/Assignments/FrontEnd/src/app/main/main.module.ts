import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { MainRoutingModule } from './main-routing.module';
import { AdminComponent } from './admin/admin.component';
import { HeaderComponent } from './admin/header/header.component';
import { FooterComponent } from './admin/footer/footer.component';
import { AddEditComponent } from './admin/add-edit/add-edit.component';
import { SearchedproductComponent } from './admin/searchedproduct/searchedproduct.component';
import { CategoryComponent } from './admin/category/category.component';
import { ProductsComponent } from './admin/products/products.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { AllproductsComponent } from './Components/allproducts/allproducts.component';
import { PageNotFoundComponent } from './admin/page-not-found/page-not-found.component';
import { CartComponent } from './Components/cart/cart.component';
import { CategoryBasedProductsComponent } from './Components/category-based-products/category-based-products.component';
import { UploadComponent } from './admin/upload/upload.component';



@NgModule({
  declarations: [
    AdminComponent,
    HeaderComponent,
    FooterComponent,
    AddEditComponent,
    SearchedproductComponent,
    CategoryComponent,
    ProductsComponent,
    DashboardComponent,
    AllproductsComponent,
    PageNotFoundComponent,
    CartComponent,
    CategoryBasedProductsComponent,
    UploadComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    MainRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class MainModule { 
}
