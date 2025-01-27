# Enter your code here. Read input from STDIN. Print output to STDOUT

lines = input()
words = {}

for p in range(int(lines)):
    word = input()
    if words.get(word):
        words[word] += 1
    else:
        words[word] = 1

print(len(words))
print(*words.values(), sep=" ")
