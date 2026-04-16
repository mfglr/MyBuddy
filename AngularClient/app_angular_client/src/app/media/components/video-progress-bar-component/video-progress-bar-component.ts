import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-video-progress-bar-component',
  imports: [],
  templateUrl: './video-progress-bar-component.html',
  styleUrl: './video-progress-bar-component.scss',
})
export class VideoProgressBarComponent {
  @ViewChild("board") board!: ElementRef<HTMLDivElement>;
  @Input() progress: number = 0;
  @Input() cache: number = 0;
  @Output() positionChange = new EventEmitter<number>();

  update(event: any){
    this.progress = event.offsetX / this.board.nativeElement.clientWidth;
    this.positionChange.emit(this.progress);
  }
}
