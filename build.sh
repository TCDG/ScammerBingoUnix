#! /bin/sh

# Example build script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build

# Change this the name of your project. This will be the name of the final executables as well.
project="ScammerBingoApp"
ftpuser="$ftplogin"
ftppassword="$ftppass"
ftphost="afroraydude.pw"
# time="$(date)"
version="master"

echo "Compiled for version $version of project $project."

echo "Attempting to build $project (version $version) for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \
  -quit

if grep -q "Compilation succeeded" "$(pwd)/unity.log"; then
 echo "Build of Windows was a success! Continuing.."
 cat $(pwd)/unity.log
else
 echo "Build Failed. See log below"
 cat $(pwd)/unity.log
 exit 1
fi

echo "Attempting to build $project (version $version) for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildOSXUniversalPlayer "$(pwd)/Build/osx/$project.app" \
  -quit

echo "Attempting to build $project (version $version)for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildLinuxUniversalPlayer "$(pwd)/Build/linux/$project" \
  -quit
  
zip -r "./scammerbingo-windows.zip" "./Build/windows/"
zip -r "./scammerbingo-mac.zip" "./Build/osx/"
zip -r "./scammerbingo-loonux.zip" "./Build/linux/"

ftp -inv $HOST << EOF

user $ftpuser $ftppassword
put ./scammerbingo-windows.zip
put ./scammerbingo-mac.zip
put ./scammerbingo-loonux.zip
put unity.log

bye

EOF

cat $(pwd)/unity.log
