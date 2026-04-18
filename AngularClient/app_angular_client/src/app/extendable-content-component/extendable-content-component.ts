import { Component, Input } from '@angular/core';
import { TruncatePipe } from '../shared/pipes/truncate-pipe';

@Component({
  selector: 'app-extendable-content-component',
  imports: [
    TruncatePipe
  ],
  templateUrl: './extendable-content-component.html',
  styleUrl: './extendable-content-component.scss',
})
export class ExtendableContentComponent {
  @Input() maxLength: number = 25;
  @Input() content!: string;
  extended: boolean = false;

  update(){
    this.extended = !this.extended;
  }
}
