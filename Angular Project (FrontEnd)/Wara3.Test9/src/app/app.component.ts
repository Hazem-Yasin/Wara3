import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router'; // Correct import for RouterOutlet

@Component({
  selector: 'app-root',
  standalone: true, // Add this to mark the component as standalone
  imports: [RouterOutlet], // Now valid with standalone: true
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Wara3.Test9';

  handleClick() {
    console.log("test");
  }
}
