import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-video-play-button-component',
  imports: [],
  templateUrl: './video-play-button-component.html',
  styleUrl: './video-play-button-component.scss',
})
export class VideoPlayButtonComponent {
  @Input() diameter: string = "64px";
  @Input() fontSize: string = "24px";
  @Input() icon: string = "▶"

  @Output() play: EventEmitter<string> = new EventEmitter<string>();

  emitPlayedEvent(){
    this.play.emit("");
  }
}
