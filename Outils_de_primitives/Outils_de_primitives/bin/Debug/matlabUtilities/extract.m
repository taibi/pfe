obj = VideoReader('primitives\\test_2.mp4');
i = 1;
tab = [];
fid = fopen('primitives\\test_2.arff','w');
nFrames = obj.NumberOfFrames;
for k = 1 : 1000 :nFrames
  fprintf(fid, '%s','test_2');
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