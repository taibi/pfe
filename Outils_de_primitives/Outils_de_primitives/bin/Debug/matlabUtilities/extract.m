function  extract(source,destination,fichierdest,TypePrimitives,label)
obj = VideoReader(source);
i = 1;
tab = [];
cd(destination);
fid = fopen(fichierdest,'w');
nFrames = obj.NumberOfFrames;
%for k = 1 : 3000 :nFrames
for k = 1 : 10
  fprintf(fid, '%s',label);
  fprintf(fid, ',%i', k);
  fprintf(fid, ',%f', obj.CurrentTime);
  this_frame = read(obj, k);
  imGray = rgb2gray(this_frame);
  cd(TypePrimitives);
  rep = lpq(imGray);
 
  fprintf(fid, ',%s', rep);
  fprintf(fid, '%s\n','');
  tab = [tab ; rep];
end

fclose(fid);