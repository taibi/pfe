function  extract(source)
obj = VideoReader(source);
i = 1;
tab = [];
fid = fopen(source&'.arff','w');
nFrames = obj.NumberOfFrames;
%for k = 1 : 3000 :nFrames
for k = 1 : 3
  fprintf(fid, '%s','test_3');
  fprintf(fid, ',%i', k);
  fprintf(fid, ',%f', obj.CurrentTime);
  this_frame = read(obj, k);
  imGray = rgb2gray(this_frame);
  rep = lpq(imGray);
 
  fprintf(fid, ',%s', rep);
  fprintf(fid, '%s\n','');
  tab = [tab ; rep];
end

fclose(fid);