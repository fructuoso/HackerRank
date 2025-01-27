#!/bin/python3

import math
import os
import random
import re
import sys



if __name__ == '__main__':
    s = input()

    letters = {}

    for letter in s:
        if letters.get(letter):
            letters[letter] += 1
        else:
            letters[letter] = 1

    sorted_letters = sorted(letters.items(), key=lambda item: (-item[1], item[0]))

    for i in range(3):
        print(sorted_letters[i][0], sorted_letters[i][1])