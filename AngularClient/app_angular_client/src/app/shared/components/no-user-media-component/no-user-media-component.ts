import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-no-user-media-component',
  imports: [],
  templateUrl: './no-user-media-component.html',
  styleUrl: './no-user-media-component.scss',
})
export class NoUserMediaComponent {
  @Input() diameter!: number;
}
