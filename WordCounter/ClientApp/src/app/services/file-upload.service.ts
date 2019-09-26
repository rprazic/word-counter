import { Injectable, Inject } from "@angular/core";
import { Observable, ObservableInput } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { catchError } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class FileUploadService {
  private _baseUrl: string;

  constructor(private _http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public postFile(fileToUpload: File): Observable<Result> {
    const endpoint = this._baseUrl + "api/TextData/CountWords";
    const formData: FormData = new FormData();
    formData.append("file", fileToUpload, fileToUpload.name);
    return this._http.post<Result>(endpoint, formData).pipe(
      catchError<Result, ObservableInput<any>>(
        (error: any, caught: Observable<Result>) => {
          throw new Error(error);
        }
      )
    );
  }
}
