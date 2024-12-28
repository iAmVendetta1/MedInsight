import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier

# Load Data
patients = pd.read_csv('symbipredict_2022.csv')

# Ensure data has 131 features
assert patients.shape[1] == 132, "Dataset should have 131 features + 1 target column"

X = patients.iloc[:, :-1].values  # All columns except the last (target)
y = patients.iloc[:, -1].values   # Target variable

# Split the data into training and hold-out sets with stratified sampling
X_train, X_hold, y_train, y_hold = train_test_split(X, y, test_size=0.2, random_state=1)

# Further split the hold-out set into validation and test sets
X_valid, X_test, y_valid, y_test = train_test_split(X_hold, y_hold, test_size=0.5, random_state=1)

# Train the RandomForest model
rf = RandomForestClassifier(n_estimators=100, max_depth=9, random_state=1)
rf.fit(X_train, y_train)
