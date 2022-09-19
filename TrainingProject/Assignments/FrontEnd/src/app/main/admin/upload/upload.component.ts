import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  progress: number | undefined;
  message: string | undefined;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http : HttpClient,private toastr : ToastrService) { }

  ngOnInit(): void {
  }
 
  uploadFile = (files : any) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    
    this.http.post('https://localhost:44355/api/upload', formData, {reportProgress: true, observe: 'events'})
      .subscribe({
        next: (event) => {
          

        // if (event.type === HttpEventType.UploadProgress)
        //   this.progress = Math.round(100 * event.loaded / event.total);
        // else if (event.type === HttpEventType.Response) {
        //   this.message = 'Upload success.';
        //   this.onUploadFinished.emit(event.body);
        // }
      },
      error: (err: HttpErrorResponse) => this.toastr.error(err.message)
    });
  }
}
