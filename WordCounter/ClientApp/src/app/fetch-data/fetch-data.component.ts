import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-fetch-data",
  templateUrl: "./fetch-data.component.html"
})
export class FetchDataComponent {
  public textDatas: TextData[];

  private _baseUrl: string;

  constructor(
    private _http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private _toastr: ToastrService
  ) {
    this._baseUrl = baseUrl;
    this._http.get<TextData[]>(this._baseUrl + "api/TextData/ReadAll").subscribe(
      result => {
        this.textDatas = result;
        this._toastr.success("Loading of texts succeeded", "Success");
      },
      error => {
        this._toastr.error("Loading of texts failed", "Error");
      }
    );
  }

  public countWords(textData: TextData): void {
    this._http.get<Result>(this._baseUrl + "api/TextData/CountWords/" + textData.id).subscribe(
      result => {
        if (result.success)
          this._toastr.success("Number of words is: " + result.count, "Success");
        else
          this._toastr.error("Word counting failed", "Error");
      },
      error => {
        this._toastr.error("Connection to server fails", "Error");
      }
    );
  }
}
