if __name__ == '__main__':
    n = int(input())

    numbers = []

    for i in range(n):
        command = input().split()
        if command[0] == 'insert':
            numbers.insert(int(command[1]), int(command[2]))
        elif command[0] == 'print':
            print(numbers)
        elif command[0] == 'remove':
            numbers.remove(int(command[1]))
        elif command[0] == 'append':
            numbers.append(int(command[1]))
        elif command[0] == 'sort':
            numbers.sort()
        elif command[0] == 'pop':
            numbers.pop()
        elif command[0] == 'reverse':
            numbers.reverse()