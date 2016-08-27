#! /bin/sh
echo 'Downloading Unity 5.3.1 pkg'
curl -o Unity.pkg http://download.unity3d.com/download_unity/a6d8d714de6f/MacEditorInstaller/Unity-5.4.0f3.pkg
echo 'Installing'
sudo installer -dumplog -package Unity.pkg -target /
