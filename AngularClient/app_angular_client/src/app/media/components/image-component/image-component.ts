import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LocalMedia } from '../../local-media';
import { LocalImageComponent } from '../local-image-component/local-image-component';
import { RemoteImageComponent } from '../remote-image-component/remote-image-component';
import { Media } from '../../media';
import { RemoteMedia } from '../../remote-media';
import { Dimension } from '../../dimension';


@Component({
  selector: 'app-image-component',
  imports: [
    LocalImageComponent,
    RemoteImageComponent
  ],
  templateUrl: './image-component.html',
  styleUrl: './image-component.scss',
})
export class ImageComponent{
  @Output() dimentionsReady = new EventEmitter<Dimension>();
  @Input() aspectRatio: number = 4 / 6;
  @Input() media!: Media;

  LocalMedia = LocalMedia;
  RemoteMedia = RemoteMedia;

  emitDimention(dimention: Dimension){
    this.dimentionsReady.emit(dimention);
  }
}
