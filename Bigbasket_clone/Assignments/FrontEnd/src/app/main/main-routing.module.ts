import { NgModule } from '@angular/core';
import { ChildrenOutletContexts, RouterModule, Routes } from '@angular/router';
import { CrudServiceService } from '../crud-service.service';
import { ErrorpageComponent } from '../errorpage/errorpage.component';
import { AddEditComponent } from './admin/add-edit/add-edit.component';
import { AdminComponent } from './admin/admin.component';
import { CategoryComponent } from './admin/category/category.component';
import { HeaderComponent } from './admin/header/header.component';
import { ProductsComponent } from './admin/products/products.component';
import { SearchedproductComponent } from './admin/searchedproduct/searchedproduct.component';
import { LoginComponent } from './Components/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './Components/home/home.component';
import { MainComponent } from './Components/main/main.component';
import { PageNotFoundComponent } from './admin/page-not-found/page-not-found.component';
import { AuthGuard } from '../_guards/auth.guard';
import { RoleGuard } from '../_guards/role.guard';

const routes: Routes = [

  {path:'', component: AdminComponent},
  // { path: '', component: HomeComponent },
  
  {
    path: 'admin', component: AdminComponent,
    canActivate: [AuthGuard,RoleGuard],

    children: [
      { path: 'user', component: ProductsComponent },
      {
        path: 'category', component: CategoryComponent,
        children: [{
          path: ':id', component: CategoryComponent,
        }],
      },
      { path: 'product', component: ProductsComponent },
      { path: 'order', component: ProductsComponent },
      {path : '' ,redirectTo: 'admin', pathMatch: 'full'},

     
    ]


  },

  { path: '**', component:PageNotFoundComponent },
  // { path: '', redirectTo: 'login', pathMatch: 'full' },


 
];

@NgModule({
  imports: [RouterModule.forChild(routes)

  ],
  exports: [RouterModule],
  providers: [CrudServiceService],
})
export class MainRoutingModule { }
