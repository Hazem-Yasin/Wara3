import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  template: `<div class="header"> {{ title() }} </div>`,
  styles:
  `
  .header
  {
    background: rgba(0,0,0,0.5);
    color: black;
    padding: 1rem;
  }
  `

})
export class HeaderComponent {
  title = signal('Angualar Ecommerce');
}
