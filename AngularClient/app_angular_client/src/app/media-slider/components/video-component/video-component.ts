import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild } from '@angular/core';
import { LocalVideoComponent } from "../local-video-component/local-video-component";
import { RemoteVideoComponent } from "../remote-video-component/remote-video-component";
import { VideoPlayButtonComponent } from '../video-play-button-component/video-play-button-component';
import { VideoProgressBarComponent } from '../video-progress-bar-component/video-progress-bar-component';
import { BaseMedia } from '../../../media-core/base-media';
import { LocalMedia } from '../../../media-core/local-media';
import { Dimension } from '../../../media-core/dimension';
import { RemoteMedia } from '../../../media-core/remote-media';

@Component({
  selector: 'app-video-component',
  imports: [
    LocalVideoComponent,
    RemoteVideoComponent,
    VideoPlayButtonComponent,
    VideoProgressBarComponent
  ],
  templateUrl: './video-component.html',
  styleUrl: './video-component.scss',
})
export class VideoComponent implements OnChanges{

  @ViewChild("video") video!: LocalVideoComponent | RemoteVideoComponent

  @Input() media!: BaseMedia;
  @Input() aspectRatio: number = 4 / 6;
  @Input() autoplay: boolean = false;
  @Input() loop: boolean = true;
  @Input() baseUrl?: string;

  @Output() dimensionsReady = new EventEmitter<Dimension>();

  LocalMedia = LocalMedia;
  RemoteMedia = RemoteMedia;

  progress: number = 0;
  cache: number = 0;
  paused: boolean = this.autoplay!;
  position: number = 0;

  ngOnChanges(changes: SimpleChanges): void {
    this.paused = !this.autoplay;
  }

  play(){
    this.video.play();
  }
  pause(){
    this.video.pause();
  }

  emitDimension(dimension: Dimension){
    this.dimensionsReady.emit(dimension);
  }

  updateProgress(progress: number){
    this.progress = progress;
  }
  updateCache(cache: number){
    this.cache = cache;
  }
  updatePlaybackState(playbackState: boolean){
    this.paused = playbackState;
  }
  updatePosition(position: number){
    this.position = position;
  }
}
