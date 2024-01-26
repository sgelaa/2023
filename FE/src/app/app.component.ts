import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FE';
  users: any;
  BASE_URL = "http://localhost:5269/api"

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get(`${this.BASE_URL}/users`).subscribe({
      next: response => {
        this.users = response
        console.log(this.users)
      },
      error: error => console.error(error),
      complete: () => console.log('request completed')
    });
  }
}
