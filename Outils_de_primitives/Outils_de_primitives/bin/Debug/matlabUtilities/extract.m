function  extract(source,destination,fichierdest,TypePrimitives,label,visage)
obj = VideoReader(source);
i = 1;
tab = [];
%mat = importdata(visage,'\n');
cd(destination);
fid = fopen(fichierdest,'w');
nFrames = obj.NumberOfFrames;
for k = 1 : nFrames
%for k = 1 : 10
  fprintf(fid, '%s',label);
  fprintf(fid, ',%i', k);
  fprintf(fid, ',%f', obj.CurrentTime);
  this_frame = read(obj, k);
  imGray = rgb2gray(this_frame);
  %imshow(imGray);
  imGrayFaceBoxe = imGray(1 : 1 + 300 , 1 : 1 + 300);
  %imshow(imGrayFaceBoxe);
  cd(TypePrimitives);
  rep = lpq(imGrayFaceBoxe);
 
  fprintf(fid, ',%s', rep);
  fprintf(fid, '%s\n','');
  tab = [tab ; rep];
end

fclose(fid);