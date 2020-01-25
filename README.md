# SSIM
Calculating average ffmpeg SSIM scores from log files

This program exists to make it easier to document the SSIM values created from ffmpeg (*ffmpeg -hide_banner -i CREATED_FILE -i ORIGINAL_FILE -lavfi ssim=ssim_CREATED_FILE.log -f null - *), in a manner that is consistent

##Syntax: 
**SSIM**
Gather all .log files in the current directory, make the average calculations and create a file (*SSIM_Result.txt*) with the .log files and the average SSIM (*LongDir.log;X.YZ*) for each file.
The log file *has* to follow the ffmpeg SSIM syntax: `n:x Y:0.999999 U:0.999999 V:0.999999 All:0.999999 (46.041675)`


**SSIM LOG_FILE.log**
Output the average SSIM for the log file.
The log file *has* to follow the ffmpeg SSIM syntax: `n:x Y:0.999999 U:0.999999 V:0.999999 All:0.999999 (46.041675)`

