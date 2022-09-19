import { Component, EventEmitter, OnInit } from '@angular/core';
import { Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  // @Output() sentParent = new EventEmitter();

  // showDropdown() {
  //   this.sentParent.emit();
  // }
  public show = true;
  constructor(private toastr : ToastrService) { }

  ngOnInit(): void {
  
    this.show = false;

  }

}
