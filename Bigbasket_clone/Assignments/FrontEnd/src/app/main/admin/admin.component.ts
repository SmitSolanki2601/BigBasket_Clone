import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UploadComponent } from './upload/upload.component';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private router: Router, private toastr : ToastrService) { }

  ngOnInit(): void {
    this.toastr.show("Welcome to Admin Panel !")
  }

  // uploadFinished = (event) => { 
  //   this.response = event; 
  // }

}
