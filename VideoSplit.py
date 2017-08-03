import cv2
import numpy as np

from scipy.misc import imsave
vidcap = cv2.VideoCapture("C:\Users\Srikrishna\Videos\Lobby\VIDEO 9\LobbyLeft2.mp4")
success, image = vidcap.read()
count = 000;
success = True
while success:
    success, image = vidcap.read()
    if (count%2 == 0):
        print('Read a new frame:', success)
        cv2.imwrite( "lobbyLeftLeft%03d.jpg" % count, image)

    #cv2.
    count+=1

