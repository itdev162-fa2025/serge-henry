<<<<<<< HEAD
import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
=======
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
>>>>>>> 2337428508d5e637f5f5be24c7594f764eb69749
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
<<<<<<< HEAD
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  title = 'client';
  posts: any;

  constructor(private http: HttpClient){}

  ngOnInit(): void{
    this.http.get('http://localhost:5289/api/posts').subscribe({
     next: (response) => this.posts = response,
     error: (e) => console.error(e),
     complete: () => console.log('complete')

=======

  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';
 weatherForecasts: any;
  constructor(private http: HttpClient){
  
  }
  ngOnInit(): void {
    this.http.get('http://localhost:5095/weatherforecast').subscribe({
      next: (Response) =>this.weatherForecasts = Response,
      error: (e) => console.error(e),
      complete: () => console.log('complete')
>>>>>>> 2337428508d5e637f5f5be24c7594f764eb69749
    })
  }
}
