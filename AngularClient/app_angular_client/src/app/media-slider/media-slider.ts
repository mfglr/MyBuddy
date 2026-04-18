import { Component, CUSTOM_ELEMENTS_SCHEMA, Input, OnChanges, QueryList, SimpleChanges, ViewChildren } from '@angular/core';
import { ImageComponent } from './components/image-component/image-component';
import { VideoComponent } from './components/video-component/video-component';
import { Dimension } from './models/dimension';
import { Media } from './models/media';
import { MediaType } from './models/media-type';
import { RemoteMedia } from './models/remote-media';

@Component({
  selector: 'app-media-slider',
  imports: [
    ImageComponent,
    VideoComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  templateUrl: './media-slider.html',
  styleUrl: './media-slider.scss',
})
export class MediaSlider implements OnChanges {
  @ViewChildren("media") elements!: QueryList<ImageComponent | VideoComponent>;
  @Input() media: Media[] = [];
  dimentions: Dimension[] = [];
  MediaType = MediaType;
  aspectRatio: number = 4 / 6;

  ngOnChanges(changes: SimpleChanges): void {
    this.dimentions = [
      ...this.media
          .filter(media => media instanceof RemoteMedia)
          .map(media => media.dimension)
    ];
    this.aspectRatio = this.dimentions.map(x => x.aspectRatio()).sort().find(() => true)!;
  }

  setDimension(dimension: Dimension){
    this.dimentions = [...this.dimentions, dimension];
    this.aspectRatio = this.dimentions.map(x => x.aspectRatio()).sort().find(() => true)!;
  }

  onSlideChange(event: any){
    let index = event.detail[0].activeIndex;
    let element = this.elements.get(index);
    if(!element)
      return;
    this.elements.filter(x => x instanceof VideoComponent).forEach(video => video.pause());
    if(element instanceof VideoComponent)
      element.play();
  }
}
