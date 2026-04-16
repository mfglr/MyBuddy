import { Component, ElementRef, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild } from '@angular/core';
import { RemoteMedia } from '../../remote-media';
import { Dimension } from '../../dimension';

@Component({
  selector: 'app-remote-video-component',
  templateUrl: './remote-video-component.html',
  styleUrl: './remote-video-component.scss',
})
export class RemoteVideoComponent implements OnChanges{
  @ViewChild("video") video!: ElementRef<HTMLVideoElement>
  @Input() media!: RemoteMedia;
  @Input() autoplay: boolean = false;
  @Input() loop: boolean = true;
  @Input() aspectRatio: number = 4 / 6;
  @Input() position: number = 0;

  @Output() progressChange = new EventEmitter<number>();
  @Output() cacheChange = new EventEmitter<number>();
  @Output() playbackStateChange = new EventEmitter<boolean>();

  paused: boolean = !this.autoplay;
  url?: string;

  ngOnChanges(changes: SimpleChanges): void {
    if(changes["autoplay"])
      this.paused = !this.autoplay;
    if(changes["position"] && this.video){
      this.video.nativeElement.currentTime = this.position * this.video.nativeElement.duration;
    }
  }

  pause(){
    this.video.nativeElement.pause();
    this.paused = true;
    this.playbackStateChange.emit(this.paused);
  }

  play(){
    this.video.nativeElement.play();
    this.paused = false;
    this.playbackStateChange.emit(this.paused);
  }

  update(){
    if(this.video && this.video.nativeElement.buffered.length > 0){
      let video = this.video.nativeElement;
      let end = video.buffered.end(video.buffered.length - 1);

      this.progressChange.emit(video.currentTime / video.duration);
      this.cacheChange.emit(end / video.duration)
    }
  }

}
