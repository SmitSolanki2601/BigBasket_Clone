import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorpageComponent } from './errorpage/errorpage.component';
import { SearchedproductComponent } from './main/admin/searchedproduct/searchedproduct.component';
import { AllproductsComponent } from './main/Components/allproducts/allproducts.component';
import { CartComponent } from './main/Components/cart/cart.component';
import { CategoryBasedProductsComponent } from './main/Components/category-based-products/category-based-products.component';
import { DashboardComponent } from './main/Components/dashboard/dashboard.component';
import { HomeComponent } from './main/Components/home/home.component';
import { LoginComponent } from './main/Components/login/login.component';
// import { LoginComponent } from './main/Components/login/login.component';

// import { ErrorpageComponent } from './errorpage/errorpage.component';
import { MainComponent } from './main/Components/main/main.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {
    path: '', component: MainComponent,
    children: [
      {
        path: '', component: DashboardComponent,
        children: [
          { path: '', component: AllproductsComponent },
        ]
      }
    ]
  },
  {path : 'login', component: LoginComponent},
//   {path : 'admin', 
//   loadChildren: () => import('./main/main.module').then(  (m) =>  m.MainModule)
// },
  { path: 'searchProducts', component: SearchedproductComponent },
  {

    path: 'dashboard', component: MainComponent,

    children:
      [
        {
          path: '', component: DashboardComponent,
          children: [
            { path: '', component: AllproductsComponent }
          ]
        },
        {
          path :'cart', component: CartComponent,
          canActivate: [AuthGuard]
        },
        {
          path:':id', component:CategoryBasedProductsComponent
        }
      ],
  },
  
  // { path: '', redirectTo: '/home', pathMatch: 'full' },
  // {
  //   path: 'app',
  //   canActivate: [AppGuard],
  //   component: HomeComponent,
  //   children: [
  //     { path: 'home', component: HomeComponent }
  //   ]
  // },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
