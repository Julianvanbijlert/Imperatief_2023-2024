

print("Bedrag: ", end="")
bedrag = float(input())
print("Rentepercentage: ", end="")
rente = float(input())

jaar = 0
while jaar<=10 :
    print(f"Na {jaar} jaar: {bedrag}")
    bedrag *= (1 + 0.01*rente)
    jaar += 1
                                                                                  #