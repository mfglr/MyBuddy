export class DimentionCalculator{

  getImageDimensions(file: File): Promise<{width:number,height:number}> {
    return new Promise((resolve, reject) => {
      const img = new Image();
      const url = URL.createObjectURL(file);
      img.onerror = reject;
      img.src = url;
      img.onload = () => {
        resolve({
          width: img.naturalWidth,
          height: img.naturalHeight
        });
        URL.revokeObjectURL(url);
      };
    });
  }
}
