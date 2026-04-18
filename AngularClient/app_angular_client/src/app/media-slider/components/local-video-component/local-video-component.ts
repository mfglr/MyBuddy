import { Component, ElementRef, EventEmitter, Input, OnDestroy, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { Dimension } from '../../../media-core/dimension';
import { LocalMedia } from '../../../media-core/local-media';

@Component({
  selector: 'app-local-video-component',
  imports: [],
  templateUrl: './local-video-component.html',
  styleUrl: './local-video-component.scss',
})
export class LocalVideoComponent implements OnInit, OnDestroy {
  @ViewChild("video") video!: ElementRef<HTMLVideoElement>
  @Input() media!: LocalMedia;
  @Input() autoplay: boolean = false;
  @Input() loop: boolean = true;
  @Input() aspectRatio: number = 4 / 6;
  @Input() position: number = 0;

  @Output() dimensionsReady = new EventEmitter<Dimension>();
  @Output() progressChange = new EventEmitter<number>();
  @Output() cacheChange = new EventEmitter<number>();
  @Output() playbackStateChange = new EventEmitter<boolean>();

  paused: boolean = !this.autoplay;
  url?: string;

  ngOnInit(): void {
    this.url = URL.createObjectURL(this.media.file);
  }
  ngOnChanges(changes: SimpleChanges): void {
    if(changes["autoplay"])
      this.paused = !this.autoplay;
    if(changes["position"] && this.video){
      let video = this.video.nativeElement;
      video.currentTime = this.position * video.duration;
    }
  }
  ngOnDestroy(): void {
    if(this.url)
      URL.revokeObjectURL(this.url);
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

  emitDimension(){
    let video = this.video.nativeElement;
    this.dimensionsReady.emit(new Dimension(video.videoWidth, video.videoHeight));
  }

  update(){
    let video = this.video.nativeElement;
    let end = video.buffered.end(video.buffered.length - 1);

    this.progressChange.emit(video.currentTime / video.duration);
    this.cacheChange.emit(end / video.duration)
  }
}
