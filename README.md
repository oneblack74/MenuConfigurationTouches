# 🎮 MenuConfigurationTouches

> 🔧 Un projet Unity qui permet de générer dynamiquement un **menu de configuration des touches** via le nouveau **Input System**.

---

## ✨ Fonctionnalités principales

- 🎛️ **Menu de rebind des touches** entièrement généré dynamiquement
- ⚙️ Basé sur le **Unity Input System**
- 🧩 Configuration simple via l’inspecteur
- 📦 **Prefab de bouton** personnalisable pour l’UI
- 🧠 Réutilisable dans n’importe quel projet Unity avec InputAction

---

## 🚀 Getting Started

### ✅ Prérequis

- **Unity 2022.3.17f1**
- Package **Input System** activé dans Unity

---

### 📥 Installation

1. Clonez le projet :
   ```bash
   git clone https://github.com/oneblack74/MenuConfigurationTouches.git
   ```
2. Ouvrez le dossier dans Unity

---

## 🕹️ Utilisation

1. Mise en place de la scène
- Créez un `GameObject` nommé InputHandler
- Attachez-lui le script `InputHandler.cs`
- Ajoutez un ScrollView comme enfant de `InputHandler`

Dans l’Inspecteur Unity, renseignez les références dans le script :
| Champ | Description |
|-------|-------------|
| Input Actions | Asset `InputAction` contenant les bindings |
| Button Prefab | Prefab utilisé pour générer chaque bouton |
| Content Transform | Transform de l’objet Content du ScrollView |

2. Génération automatique
🎉 Le menu se génère automatiquement à partir de l’InputAction asset fourni.
Chaque action aura un bouton de rebind dans l’UI.

```
Assets/
├──KeyBinding/
│  ├── Scripts/
│  │   └── InputHandler.cs
│  ├── Prefabs/
│  │   └── ButtonPrefab.prefab
│  └── Scenes/
│      └──SampleScene.unity
└── Input/
    └── InputActions.inputactions

```

---

## 📌 État du projet

🧪 En développement

---

## 👤 Auteur

Axel Brissy
    🔗 [GitHub](https://github.com/oneblack74)

---

