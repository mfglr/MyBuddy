export class PostId {
  localId: string;
  remoteId?: string;

  private constructor(localId: string, remoteId?: string) {
    this.localId = localId;
    this.remoteId = remoteId;
  }

  static create(): PostId{
    return new PostId(crypto.randomUUID());
  }

  setRemoteId(remoteId:string) : PostId{
    return new PostId(this.localId,remoteId);
  }
}
