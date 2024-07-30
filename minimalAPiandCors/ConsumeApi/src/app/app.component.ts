import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Person } from './models/person';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{

  public http: HttpClient = inject(HttpClient);
  public urlApi: string = 'http://localhost:5206/persons';
  public persons: Person[] = []

  public getAllPerson(){
    this.http.get<Person[]>(this.urlApi).subscribe(
      p => this.persons = p
    )
  }

  ngOnInit(): void {
    this.getAllPerson()
  }



  
}
