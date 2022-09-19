import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import {PasswordModule} from 'primeng/password';
import {ButtonModule} from 'primeng/button';
import {ToastModule} from 'primeng/toast';
import {RippleModule} from 'primeng/ripple';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { CrudServiceService } from './crud-service.service';
import { LoginComponent } from './main/Components/login/login.component';
import { HomeComponent } from './main/Components/home/home.component';
import { ErrorpageComponent } from './errorpage/errorpage.component';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
// import { ToastrModule } from 'ngx-toastr';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatRippleModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { HeaderComponent } from './main/Components/header/header.component';
import { FooterComponent } from './main/Components/footer/footer.component';
import { MainComponent } from './main/Components/main/main.component';
import { MainModule } from './main/main.module';
import { ToastrModule } from 'ngx-toastr';
   



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    ErrorpageComponent,
    HeaderComponent,
    FooterComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MainModule,
    BrowserAnimationsModule,
    ToastModule,
    ToastrModule.forRoot({
      
      positionClass:'toast-bottom-right'

  }),

    ButtonModule,
    RippleModule,
    FormsModule,
    PasswordModule,
    HttpClientModule,ReactiveFormsModule

  ],
  providers: [CrudServiceService],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  exports: [
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,

],

  bootstrap: [AppComponent],
  
})
export class AppModule { }
