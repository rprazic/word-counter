import { Component } from "@angular/core";
import { ToastrService } from "ngx-toastr";

import { FileUploadService } from "../services/file-upload.service";

@Component({
  selector: "app-upload-component",
  templateUrl: "./upload.component.html"
})
export class UploadComponent {
  public fileToUpload: File = null;

  constructor(
    private _toastr: ToastrService,
    private _fileUploadService: FileUploadService
  ) {}

  public handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }

  uploadFile() {
    this._fileUploadService.postFile(this.fileToUpload).subscribe(
      result => {
        if (result.success)
          this._toastr.success(
            "Number of words is: " + result.count,
            "Success"
          );
        else this._toastr.error("Cannot read from non .txt file", "Error");
      },
      error => {
        this._toastr.error("Connection to server fails", "Error");
      }
    );
  }
}
