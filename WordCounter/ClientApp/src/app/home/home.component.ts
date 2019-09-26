import { Component, ViewChild, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { FormGroup, NgForm, FormControl } from "@angular/forms";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html"
})
export class HomeComponent implements OnInit {
  private _baseUrl: string;

  public editor = ClassicEditor;

  public data: string = "";

  public editorConfig = {
    placeholder: "Type the content here!"
  };

  @ViewChild("editorForm", { static: true })
  public editorForm: NgForm;

  public form: FormGroup;

  constructor(
    private _http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private _toastr: ToastrService
  ) {
    this._baseUrl = baseUrl;
  }

  public ngOnInit() {
    let group = {};
    group["data"] = new FormControl(this.data);
    this.form = new FormGroup(group);
  }

  submit() {
    let text = this.form.value["data"];
    if (text === '') {
      this._toastr.warning(
        "You don't have any word",
        "Warning"
      );
      return;
    }

    this._http
      .get<Result>(
        this._baseUrl + "api/TextData/CountWords?text=" + text
      )
      .subscribe(
        result => {
          if (result.success)
            this._toastr.success(
              "Number of words is: " + result.count,
              "Success"
            );
          else this._toastr.error("Word counting failed", "Error");
        },
        error => {
          this._toastr.error("Connection to server fails", "Error");
        }
      );
  }
}
