import { Component, Input } from '@angular/core';
import { PostUserCardComponent } from '../post-user-card-component/post-user-card-component';
import { MediaSlider } from '../../../media-slider/media-slider';
import { Post } from '../../models/post';
import { RemoteMedia } from '../../../media-core/remote-media';
import { Media } from '../../../media-core/media';
import { Dimension } from '../../../media-core/dimension';
import { TruncatePipe } from '../../../shared/pipes/truncate-pipe';

@Component({
  selector: 'app-post-component',
  imports: [
    PostUserCardComponent,
    MediaSlider,
  ],
  templateUrl: './post-component.html',
  styleUrl: './post-component.scss',
})
export class PostComponent {
  @Input() post!: Post;
  @Input() baseUrl!: string;
  @Input() userMediaDiameter: number = 48;

  map(media: Media): RemoteMedia{
      return new RemoteMedia(
        media.containerName,
        media.blobName,
        media.type,
        new Dimension(media.metadata.width, media.metadata.height)
      )
    }
}
