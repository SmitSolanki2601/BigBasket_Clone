import { Component, OnInit } from '@angular/core';
import {MessageService} from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
// import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';

// @Component({
//   selector: 'app-root',
//   templateUrl: './app.component.html',
//   // styleUrls: ['./app.component.css']
// })

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [MessageService]
})

export class AppComponent implements OnInit {

  constructor(private primengConfig: PrimeNGConfig){}


  ngOnInit() {
    this.primengConfig.ripple = true;
  }
}



