import { Component, Input } from '@angular/core';
import { LocalMedia } from '../../../media-core/local-media';

@Component({
  selector: 'app-local-media-circular',
  imports: [],
  templateUrl: './local-media-circular.html',
  styleUrl: './local-media-circular.scss',
})
export class LocalMediaCircular {
  @Input() diameter : number = 60;
  @Input() image!: LocalMedia;
  url?: string;

  ngOnInit(): void {
    this.url = URL.createObjectURL(this.image.file);
  }
  ngOnDestroy(): void {
    if(this.url)
      URL.revokeObjectURL(this.url);
  }
}
