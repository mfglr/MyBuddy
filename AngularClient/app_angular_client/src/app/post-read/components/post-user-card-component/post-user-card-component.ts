import { Component, Input } from '@angular/core';
import { Post } from '../../models/post';
import { MediaCircular } from '../../../media-circular/media-circular';
import { NoUserMediaComponent } from '../../../shared/components/no-user-media-component/no-user-media-component';
import { RemoteMedia } from '../../../media-core/remote-media';
import { Media } from '../../../media-core/media';
import { Dimension } from '../../../media-core/dimension';
import { TruncatePipe } from '../../../shared/pipes/truncate-pipe';

@Component({
  selector: 'app-post-user-card-component',
  imports: [
    MediaCircular,
    NoUserMediaComponent,
    TruncatePipe
  ],
  templateUrl: './post-user-card-component.html',
  styleUrl: './post-user-card-component.scss',
})
export class PostUserCardComponent {
  @Input() post!: Post;
  @Input() diameter: number = 32;
  @Input() baseUrl!: string;

  map(media: Media): RemoteMedia{
    return new RemoteMedia(
      media.containerName,
      media.blobName,
      media.type,
      new Dimension(media.metadata.width,media.metadata.height)
    )
  }
}
